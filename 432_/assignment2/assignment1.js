// Import the installed modules.
const express = require('express');
const responseTime = require('response-time')
const axios = require('axios');
const redis = require('redis');
var convert = require('xml-js');
const app = express();

// create and connect redis client to local instance.
const client = redis.createClient();

// Print redis errors to the console
client.on('error', (err) => {
    console.log("Error " + err);
});

// use response-time as a middleware
app.use(responseTime());


// create an api/search route
app.get('/api/search', (req, res) => {
    // Extract the query from url and trim trailing spaces
    //const query = (req.query.query).trim();
    // Build the Wikipedia API url
    const searchUrl = `https://news.google.com/rss/search?q=bitcoin&hl=en-US&gl=US&ceid=US:en`;


    // check if its in the redis 
    // if not check it from mongodb  if still not in mongodb, run the axios call and save the result in redis & mongodb
    // if it is in redis get it from redis 

    axios({
        method: "get",
        url: searchUrl,
        responseType: "type"
    }).then(function (response) {
        var options = { ignoreComment: true, alwaysChildren: true };
        const jason = convert.xml2json(response.data, options)
        const weirdo = JSON.parse(jason)


        // console.log(weirdo.elements[0].elements[0].elements[8].elements[0].elements[0].text)
        // console.log(weirdo.elements[0].elements[0].elements[8].elements[1].elements[0].text)
        // console.log("******")
        // console.log(weirdo.elements[0].elements[0].elements[9].elements[0].elements[0].text)
        // console.log(weirdo.elements[0].elements[0].elements[9].elements[1].elements[0].text)
        // console.log("******")
        // console.log(weirdo.elements[0].elements[0].elements[10].elements[0].elements[0].text)
        // console.log(weirdo.elements[0].elements[0].elements[10].elements[1].elements[0].text)
        // console.log("******")
        // console.log(weirdo.elements[0].elements[0].elements.length)

        for (let i = 8; i < weirdo.elements[0].elements[0].elements.length; i++) {

            console.log(weirdo.elements[0].elements[0].elements[i].elements[0].elements[0].text)
            console.log(weirdo.elements[0].elements[0].elements[i].elements[1].elements[0].text)
        }


    });











    // Try fetching the result from Redis first in case we have it cached
    return client.get(`google new feed:`, (err, result) => {

        console.log()
        // If that key exist in Redis store
        if (result) {
            const resultJSON = JSON.parse(result);
            return res.status(200).json(resultJSON);
        } else { // Key does not exist in Redis store
            // Fetch directly from Wikipedia API
            return axios.get(searchUrl)
                .then(response => {
                    const responseJSON = response.data;
                    // Save the Wikipedia API response in Redis store
                    client.setex(`wikipedia:${query}`, 3600, JSON.stringify({ source: 'Redis Cache', ...responseJSON, }));
                    // Send JSON response to client
                    return res.status(200).json({ source: 'Wikipedia API', ...responseJSON, });
                })
                .catch(err => {
                    return res.json(err);
                });
        }
    });
});

app.listen(3000, () => {
    console.log('Server listening on port: ', 3000);
});