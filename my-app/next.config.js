const path = require("path");
/** @type {import('next').NextConfig} */
const nextConfig = {
  webpack: (config, options) => {
    options.isServer = false;
    return {
      ...config,
      entry: () => {
        let entries = config.entry().then((entry) => {
          let c = Object.assign({}, entry, {
            "woker": {
              import: "./src/app/worker/fff.js",
              filename: "fasfasf.js",
              publicPath: path.resolve(__dirname, ".next/static/chunks"),
              layer:"rsc", 
              dependOn : undefined
            },
          });
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
