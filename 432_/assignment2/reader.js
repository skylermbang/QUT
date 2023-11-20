const { MongoClient } = require('mongodb');
const createStream = require('./tweet');
const url = 'mongodb://localhost:27017/asg2';
//const url = "mongodb+srv://test:test@cluster0.2aerj.mongodb.net/myFirstDatabase?retryWrites=true&w=majority"
const dbName = 'asg2';
// Create a MongoDB client instance
const client = new MongoClient(url, { useNewUrlParser: true });
// Calculate the keyword score and save the score along with the keyword analysis data
const calculateAndStore = async (db, keyword) => {
    const data = db.collection(`keyword_${keyword}`);
    const positive = await data.countDocuments({ score: 1 });
    const negative = await data.countDocuments({ score: -1 });
    const total = await data.estimatedDocumentCount();
    const trend = ((positive - negative) / total) * 100;
    const Calc = db.collection('calc');
    await db.createIndex('calc', { keyword: 1 }, { unique: true });
    // update db
    await Calc.updateOne(
        { keyword },
        {
            $set: {
                //price: stats.last,
                //change,
                trend,
                tweetCount: {
                    positive: positive,
                    negative: negative,
                    neutral: total - positive - negative,
                },
                createAt: new Date(),
            },
        },
        { upsert: true },
    );
};
// Create keyword 
const createIndex = async (db, keyword) => {
    const index = Promise.all([
        db.createIndex(
            `keyword_${keyword}`,
            {
                score: 1,
                id: 1,
                timestamp_ms: -1,
            },
            {
                unique: true,
            },
        ),
        db.createIndex(
            `keyword_${keyword}`,
            {
                createdAt: 1,
            },
            {
                expireAfterSeconds: 60 * 60 * 24,
            },
        ),
    ]);
    return index;
};

const register = async (db, keyword, interval) => {
    await createIndex(db, keyword);
    createStream(db, keyword);
    calculateAndStore(db, keyword);
    setInterval(() => {
        calculateAndStore(db, keyword);
    }, interval);
};

(async () => {
    try {
        await client.connect();
        const db = client.db(dbName);
        // hardcoding bitcoin keyword
        await register(db, "bitcoin", 3000);
        console.log("Keyword was has been registered")
    } catch (err) {
        console.log(err.stack);
    }
})();