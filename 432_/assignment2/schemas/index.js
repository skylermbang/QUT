const mongoose = require("mongoose");

const connect = () => {
  mongoose

    //  test:test id/pws @ ip
    //  mongodb://test:test@13.125.199.244:27017 => aws
    // mongodb://localhost/asg2 => local
    //mongodb://test:test@13.211.156.4:27017   this is aws
    //  mongodb://localhost/asg2    this is local 
    //mongodb://test:test@13.239.37.102:27017 
    //"mongodb+srv://test:test@cluster0.2aerj.mongodb.net/myFirstDatabase?retryWrites=true&w=majority "

    .connect("mongodb://localhost/asg2", {
      useNewUrlParser: true,
      useUnifiedTopology: true,

    })
    .catch((err) => console.log(err));
};


// const { MongoClient } = require('mongodb');
// const uri = "mongodb+srv://test:test@cluster0.2aerj.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
// const client = new MongoClient(uri, { useNewUrlParser: true, useUnifiedTopology: true });
// client.connect(err => {
//   const collection = client.db("test").collection("devices");
//   // perform actions on the collection object
//   client.close();
// });

mongoose.connection.on("error", (err) => {
  console.error("mongoDB connection error ", err);
});

module.exports = connect;
