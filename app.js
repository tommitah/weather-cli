const fetch = require("node-fetch")
const readline = require('readline')
const read = readline.createInterface({
  input: process.stdin,
  output: process.stdout
})

const api_url_start = "http://api.openweathermap.org/data/2.5/weather?q="
const api_url_end = "&units=metric&APPID=cc2928d46d101dbdb1a0e1b6b9af5e54"

let location = ""

async function getWeather(location) {
  fetch(api_url_start + location + api_url_end)
    .then(res => res.json())
    .then(json => console.log(
      "Weather in " + location + ":\n\t" + json.weather[0].main +
      "\n\tTemperature: " + json.main.temp + " Celsius" +
      "\n\tHumidity: " + json.main.humidity + " %"
    ))
  }

read.question('SEND LOCATION: ', (answer) => {
  getWeather(answer)
  read.close()
})

