const express = require('express');
const helmet = require('helmet');
const { MongoClient, ObjectID } = require('mongodb');
const router = require('express').Router();
const url = process.env.MONGO_URL || 'mongodb://localhost:27017/twtsnt';
const dbName = 'twtsnt';
let client = null;


// Get a database instance
async function getDB() {
    if (client && !client.isConnected) {
        client = null;
    }

    if (client === null) {
        client = new MongoClient(url, { useNewUrlParser: true });
    } else if (client && client.isConnected) {
        return client.db(dbName);
    }

    try {
        await client.connect();
        return client.db(dbName);
    } catch (err) {
        return err;
    }
}

// HTTP Security header middleware
router.use(helmet());





// Get score from the given keyword    i.e.) /api/score?keyword=bitcoin
router.get('/btc', async (req, res) => {
    try {
        const keyword = "bitcoin"
        const db = await getDB();
        const resp = {};
        const collection = db.collection('calc');
        const data = await collection.findOne({ keyword });



        const { neutral, positive, negative } = data.tweetCount

        const chart = {
            neutral,
            positive,
            negative
        }

        console.log(chart)
        res.render("chart");

    } catch (err) {
        res.status(500).json({
            message: err.message,
        });
    }
});

router.get('/eth', async (req, res) => {
    try {
        const keyword = "ethereum"
        const db = await getDB();
        const resp = {};
        const collection = db.collection('calc');
        const data = await collection.findOne({ keyword });
        res.json({
            keyword,
            data,
        });
    } catch (err) {
        res.status(500).json({
            message: err.message,
        });
    }
});



module.exports = router;