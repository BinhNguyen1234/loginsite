const path = require("path");
/** @type {import('next').NextConfig} */
const nextConfig = {
  reactStrictMode: false,
  webpack: (config, options) => {
    options.isServer = false;
    return {
      ...config,
      entry: () => {
        let entries = config.entry().then((entry) => {
          let c = Object.assign({}, entry);
          return c;
        });
        return entries;
      },
    };
  },
};

module.exports = nextConfig;
// worker: {
//   import: "./src/app/worker/fff.js",
//   filename: "fasfasf.js",
//   dependOn: undefined,
//   publicPath: "./stactic"
// }
