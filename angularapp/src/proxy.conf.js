


const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:44340",

    secure: false
  }
]

module.exports = PROXY_CONFIG;
