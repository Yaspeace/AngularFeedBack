const PROXY_CONFIG = [
  {
    context: [
      "/publish",
    ],
    target: "http://tzangular.somee.com",
    secure: false,
    changeOrigin: true
  }
]

module.exports = PROXY_CONFIG;
