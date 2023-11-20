
const helmet = require('helmet');
const { MongoClient, ObjectID } = require('mongodb');
const router = require('express').Router();
const url = 'mongodb://localhost:27017/asg2';
//const url = "mongodb+srv://test:test@cluster0.2aerj.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
const dbName = 'asg2';
let client = null;


// connecting to mongoDB
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


// Get Sentimental analysis data   i.e.) /api/score?keyword=bitcoin
router.get('/api/score', async (req, res) => {
    try {
        const db = await getDB();
        if (!req.query.keyword) {
            res.status(400).json({ message: 'missing keyword' });
        }

        const keyword_input = req.query.keyword;
        console.log("keyword is : ", keyword_input)
        const Calc = db.collection('calc');
        const data = await Calc.findOne({ keyword: keyword_input });
        res.json({
            keyword: keyword_input,
            data,
        });
    } catch (err) {
        res.status(500).json({
            message: err.message,
        });
    }
});

// Get  tweets data
router.get('/api/tweets', async (req, res) => {
    try {
        const db = await getDB();
        if (!req.query.keyword) {
            res.status(400).json({ message: 'no keyword input' });
        }

        const resp = {};
        const keyword = req.query.keyword;
        let limit;
        if (!!req.query.limit) {
            req.query.limit = Number(req.query.limit);
        }
        // Get documents (limit 1 - 100)
        if (req.query.limit > 0 && req.query.limit <= 100) {
            limit = req.query.limit;
        } else {
            limit = 100;
        }
        resp.limit = limit;

        let collection = db.collection(`keyword_${keyword}`);

        const skip = req.query.skip;
        if (skip) {
            resp.skip = skip;
            // use MongoID index is given by default, no need to make extra index for this
            collection = collection.find({ _id: { $lt: new ObjectID(skip) } });
        } else {
            collection = collection.find();
        }
        resp.tweets = await collection.sort({ _id: -1 }).limit(limit).toArray();
        res.json(resp);
    } catch (err) {
        res.status(500).json({
            message: err.message,
        });
    }
});

module.exports = router;