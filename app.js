// MODULES 
const fetch = require("node-fetch")
const readline = require('readline')
const read = readline.createInterface({
  input: process.stdin,
  output: process.stdout
})

// API URL, two pieces 
// -> user inputs location which is pasted in the middle
const api_url_start = "http://api.openweathermap.org/data/2.5/weather?q="
const api_url_end = "&units=metric&APPID=cc2928d46d101dbdb1a0e1b6b9af5e54"

let location = ""

// OUTPUT, prints a formatted snippet from the JSON
function printFormatJSON(json, location) {
  console.log(
    `Weather in ${location}:
      \t${json.weather[0].main}
      \tTemperature: ${json.main.temp} Celsius
      \tHumidity: ${json.main.humidity} %`
  )
}

// FETCH, requests the data from API in JSON format
// ,then outputs some.
async function getWeather(location) {
  fetch(api_url_start + location + api_url_end)
    .then(res => res.json())
    .then(json => printFormatJSON(json, location))
}

// the 'main'
// the readline module reads user input from cli and makes the API call.
read.question('SEND LOCATION: ', (answer) => {
  getWeather(answer)
  read.close()
})
