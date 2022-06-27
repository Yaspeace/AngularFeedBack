const PROXY_CONFIG = [
  {
    context: [
      "/feedback",
    ],
    target: "https://localhost:7276",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
