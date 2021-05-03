const fs = require('fs')
const readline = require('readline')
const read = readline.createInterface({
  input: process.stdin,
  ouput: process.stdout
})

let i = 0

var array = fs.readFileSync('thousand_words.txt').toString().split("\n")

async function compare(word) {
  return array[i] === (word + ' ')
}

async function type() {
  console.log(array[i].toString())
  read.question(`${array[i]}`, (answer) => {
    if (compare(answer)) i++
  })
}

type()



