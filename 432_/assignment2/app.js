const express = require("express");
const app = express();
const port = 3000;

app.use(express.urlencoded({ extended: false })); // request.body ?  to get
app.use(express.json());
// middelware :  static file
app.use(express.static("public"));

// mongodb schemas and connect
const connect = require("./schemas");
connect();


//ejs
app.set("views", __dirname + "/views");
app.set("view engine", "ejs");


// router for tweeter 
const tweetRouter = require("./api")
app.use("/tweeter", [tweetRouter])

// router for article
const articleRouter = require("./article")
app.use("/article", [articleRouter])


app.get("/", (req, res, next) => {
  res.render("index");
});


app.get("/pi", (req, res, next) => {

  res.render("pi");
});


app.listen(port, () => {
  console.log(`listening at http://localhost:${port}`);
});
