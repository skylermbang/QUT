const express = require("express");

const app = express();
const port = 3000;
const Date = require("./date");


// this is middleware for processing the data
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

const articleRouter = require("./article")
app.use("/article", [articleRouter])


app.get("/", (req, res, next) => {

  res.render("index");
});


app.get("/pi", (req, res, next) => {

  res.render("pi");
});



app.get("/test", (req, res) => {
  let name = req.query.name;
  res.render("test", { name });
});

app.listen(port, () => {
  console.log(`listening at http://localhost:${port}`);
});
