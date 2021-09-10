const express = require("express");
const jwt = require("jsonwebtoken");
const Joi = require("joi");
const app = express();
const port = 8111;
const Date = require("./date");
const authMiddleware = require("./middlewares/auth-middleware");

// this is middleware for processing the data
app.use(express.urlencoded({ extended: false })); // request.body ?  to get
app.use(express.json());
// middelware :  static file
app.use(express.static("public"));


//ejs
app.set("views", __dirname + "/views");
app.set("view engine", "ejs");


app.use((req, res, next) => {
  //console.log(req);
  next();
});


app.get("https://www.travel-advisory.info/api", (req, res) => {
  res.send("data")
})


app.get("/", (req, res, next) => {
  res.render("index")

});

app.listen(port, () => {
  console.log(`listening at http://localhost:${port}`);
});
