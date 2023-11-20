const mongoose = require("mongoose");

const connect = () => {
  mongoose

    //  test:test id/pws @ ip
    //  mongodb://test:test@13.125.199.244:27017 => aws
    // mongodb://localhost/asg2 => local
    //mongodb://test:test@13.211.156.4:27017   this is aws
    //  mongodb://localhost/asg2    this is local 
    .connect("mongodb://test:test@54.252.158.115:27017 ", {
      useNewUrlParser: true,
      useUnifiedTopology: true,
      useCreateIndex: true,
      ignoreUndefined: true,
    })
    .catch((err) => console.log(err));
};

mongoose.connection.on("error", (err) => {
  console.error("mongoDB connection error ", err);
});

module.exports = connect;
