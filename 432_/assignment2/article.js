// Import the installed modules.
const express = require('express');
const responseTime = require('response-time')
const axios = require('axios');
const redis = require('redis');
var convert = require('xml-js');
const app = express();

const router = require('express').Router();
// mongodb schemas and connect
const connect = require("./schemas");
const Article = require('./schemas/articles')
connect();


// create and connect redis client to local instance.
const client = redis.createClient();

// Print redis errors to the console
client.on('error', (err) => {
    console.log("Error " + err);
});

// use response-time as a middleware
app.use(responseTime());


// create an api/search route
router.get('/google', (req, res) => {
    const result_array = [];
    const redis_array = [];
    const mongodb_array = [];
    const searchUrl = `https://news.google.com/rss/search?q=bitcoin&hl=en-US&gl=US&ceid=US:en`;


    //load_mongo()

    // check if its in the redis 
    async function get_redis() {
        client.get("article8", function (err, reply) {


            let redis_result = reply.toString()
            let redis_title = redis_result.split("+")[0]
            let redis_url = redis_result.split("+")[1]
            const redis_response = {
                title: redis_title,
                url: redis_url
            }
            //console.log(redis_response)
            //redis_array.push(redis_response)
            console.log(" get redis data article 8")

        }.then(() => { redis_array.push(redis_response) })

        )
        client.get("article9", function (err, reply) {
            //console.log("*******")
            if (reply) {
                let redis_result = reply.toString()
                let redis_title = redis_result.split("+")[0]
                let redis_url = redis_result.split("+")[1]
                const redis_response = {
                    title: redis_title,
                    url: redis_url
                }
                //console.log(redis_response)
                redis_array.push(redis_response)
                console.log(" get redis data article 9")
            }
        })
        console.log(redis_array)
    }







    // axios({
    //     method: "get",
    //     url: searchUrl,
    //     responseType: "type"
    // }).then(async function (response) {
    //     var options = { ignoreComment: true, alwaysChildren: true };
    //     const jason = convert.xml2json(response.data, options)
    //     const weirdo = JSON.parse(jason)


    //     //for (let i = 8; i < weirdo.elements[0].elements[0].elements.length; i++) {
    //     for (let i = 8; i < 10; i++) {

    //         const title = weirdo.elements[0].elements[0].elements[i].elements[0].elements[0].text
    //         const url = weirdo.elements[0].elements[0].elements[i].elements[1].elements[0].text


    //         const api_response = {
    //             title: title,
    //             url: url
    //         }

    //         result_array.push(api_response)
    //         // save_mongo(title, url)
    //         // save_redis(api_response, i)
    //         //console.log(weirdo.elements[0].elements[0].elements[i].elements[0].elements[0].text)
    //         //console.log(weirdo.elements[0].elements[0].elements[i].elements[1].elements[0].text)
    //     }
    // }).then(async (title, url, api_response, i) => {
    //     console.log("*******")
    //     console.log(result_array)
    //     console.log(title, "this is from then")
    //     console.log("*******")

    // }).then(async (title, url, api_response, i) => {
    //     await console.log("&&&&&")
    //     await console.log(redis_array)
    //     await console.log("&&&&&")
    //     await console.log("#####")
    //     await console.log(mongodb_array)
    //     await console.log("#####")


    //     if (result_array[0].title === redis_array[0].title) {

    //         console.log(" this is from redis")
    //         return res.json({ "result": redis_array })
    //     } else if (result_array[0].title === mongodb_array[0].title) {
    //         console.log(" this is from mongodb")
    //         save_redis(api_response, i)
    //         return res.json({ "result": mongodb_array })
    //     } else {
    //         console.log(" not in redis nor mongo ")
    //         save_mongo(title, url)
    //         save_redis(api_response, i)
    //         return res.json({ "result": result_array })
    //     }
    // })





    // if (title === redis_title) {
    //     // get all redis data and send to client 
    //     //return res.json(result)
    // }

    // let redis_result = client.get("article7")
    // console.log("*******")
    // console.log(redis_result)
    // console.log("*******")


    async function save_mongo(title, url) {
        let isExist = await Article.findOne({ title })
        if (isExist) {
            console.log("Already in DB")
        } else {
            await Article.create({

                title,
                url

            })
            console.log("save in mongo")
        }
    }

    async function load_mongo(title, url,) {
        let isExist = await Article.find().sort({ '_id': -1 })
        // console.log(isExist[0].title)
        for (let i = 0; i < 3; i++) {
            let mongo_title = isExist[i].title
            let mongo_url = isExist[i].url
            const mongo_response = {
                title: mongo_title,
                url: mongo_url
            }

            mongodb_array.push(mongo_response)
        }
    }

    async function save_redis(redis, i) {

        client.setex(`article${i}`, 3600, `${redis.title}+${redis.url}`);
        console.log("saved in redis")


    }


    //Try fetching the result from Redis first in case we have it cached
    return client.get(`article8`, (err, result) => {
        console.log("start")
        // If that key exist in Redis store
        if (result) {
            let redis_result = result.toString()
            let redis_title = redis_result.split("+")[0]
            let redis_url = redis_result.split("+")[1]
            const redis_response = {
                title: redis_title,
                url: redis_url
            }
            //const resultJSON = JSON.parse(result);
            console.log("this is from redis")
            return res.status(200).json({ "result": redis_response });
        } else { // Key does not exist in Redis store
            // Fetch directly from Wikipedia API
            load_mongo()
            console.log("no data in redis")
            return axios.get(searchUrl)
                .then(response => {

                    var options = { ignoreComment: true, alwaysChildren: true };
                    const jason = convert.xml2json(response.data, options)
                    const weirdo = JSON.parse(jason)
                    //for (let i = 8; i < weirdo.elements[0].elements[0].elements.length; i++) {
                    for (let i = 8; i < 10; i++) {
                        const title = weirdo.elements[0].elements[0].elements[i].elements[0].elements[0].text
                        const url = weirdo.elements[0].elements[0].elements[i].elements[1].elements[0].text
                        const api_response = {
                            title: title,
                            url: url
                        }
                        result_array.push(api_response)
                        save_mongo(title, url)
                        client.setex(`article${i}`, 3600, `${title}+${url}`);
                    }


                    console.log("*****")
                    console.log(result_array)
                    console.log("*****")
                    console.log("@@@@")
                    console.log(mongodb_array)
                    console.log("@@@")
                    if (result_array[0].title === mongodb_array[0].title) {
                        console.log("data from mongodb ")
                        return res.json({ "result": mongodb_array })
                    } else {
                        const responseJSON = response.data;
                        // Save the Wikipedia API response in Redis store
                        //client.setex(`wikipedia:${query}`, 3600, JSON.stringify({ source: 'Redis Cache', ...responseJSON, }));
                        // Send JSON response to client
                        for (let i = 0; i < result_array.length; i++) {
                            const title = result_array[i].title
                            const url = result_array[i].url
                            save_mongo(title, url)
                        }

                        console.log("data from API")
                        return res.status(200).json({ "result": result_array });
                    }

                    // const responseJSON = response.data;
                    // // Save the Wikipedia API response in Redis store


                    // //client.setex(`wikipedia:${query}`, 3600, JSON.stringify({ source: 'Redis Cache', ...responseJSON, }));
                    // // Send JSON response to client
                    // return res.status(200).json({ "result": result_array });
                })
                .catch(err => {
                    return res.json(err);
                });
        }
    });
});

module.exports = router;