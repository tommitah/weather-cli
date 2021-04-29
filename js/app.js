// MODULES 
// api key hidden from version control, api-key.js exports two-piece module.
const key = require("./api-key.js")
const fetch = require("node-fetch")
const readline = require('readline')
const read = readline.createInterface({
  input: process.stdin,
  output: process.stdout
})

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
  fetch(`${key.API_KEY_START}${location}${key.API_KEY_END}`)
    .then(res => res.json())
    .then(json => printFormatJSON(json, location))
    .catch(err => {
      console.log(`${location} is not a valid search argument.\n${err}`)
    })
}

// the 'main'
// the readline module reads user input from cli and makes the API call.
read.question('SEND LOCATION: ', (answer) => {
  getWeather(answer)
  read.close()
})
