require('dotenv').config();
const Sentiment = require('sentiment');
const Twit = require('twit');

// Create a sentiment instance
const sentiment = new Sentiment();

// Create a Twit instance
const T = new Twit({
    consumer_key: process.env.TWITTER_API,
    consumer_secret: process.env.TWITTER_API_SECRET,
    access_token: process.env.TWITTER_API_ACCESS_TOKEN,
    access_token_secret: process.env.TWITTER_API_TOKEN_SECRET,
    timeout_ms: 60 * 1000, // optional HTTP request timeout to apply to all requests.
    strictSSL: true, // optional - requires SSL certificates to be valid.
});

// Take a MongoDB depend on the keyword
module.exports = (db, keyword) => {
    // stream depeond on the keyword input
    const stream = T.stream('statuses/filter', {
        track: keyword,
    });

    stream.on('tweet', async tweet => {
        const {
            created_at,
            id,
            lang,
            text,
            user: { screen_name, profile_image_url_https },
            timestamp_ms,
        } = tweet;

        // Since the sentiment only supports English
        if (lang === 'en') {
            let { score } = sentiment.analyze(text);
            if (score > 0) { // Treat greater than zero as 1
                score = 1;
            } else if (score < 0) { // Treat less than zero as -1
                score = -1;
            }

            // Save the tweet information with the score in the keyword collection
            await db.collection(`keyword_${keyword}`).insertOne({
                score,
                createdAt: new Date(created_at),
                id,
                lang,
                text,
                screen_name,
                profile_image_url_https,
                timestamp_ms,
            });
        }
    });
};