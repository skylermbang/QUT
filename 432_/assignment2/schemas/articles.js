const mongoose = require("mongoose");
const { Schema } = mongoose;

const articleSchema = new Schema({

  title: {
    type: String,
  },
  url: {
    type: String,
  },

});

module.exports = mongoose.model("article", articleSchema);
