const path = require("path");
const webpack = require("webpack");
// import { CleanWebpackPlugin } from 'clean-webpack-plugin'
const _dirName = path.dirname(__dirName)
console.log(_dirName)
const configCommon = {
    entry: path.resolve(_dirName, 'src', 'index.tsx'),
    output: {
        path: path.resolve(_dirName, 'dist')
    },
    plugins: [
        new HtmlWebpackPlugin({
            template: path.resolve(_dirName, 'src', 'app', 'index.html'),
            filename: 'index.html'
        }),
        new Dotenv(),
        new CleanWebpackPlugin(),
        new webpack.ProgressPlugin(),
        new MiniCssExtractPlugin(),
        new webpack.ProvidePlugin({
            React: 'react',
            _: 'lodash'
        })
    ],
    module: {
        rules: [
            {
                test: /\.(ts|tsx)$/i,
                use: [{ loader: 'babel-loader' }, { loader: 'ts-loader' }],
                exclude: ['/node_modules/'],
                sideEffects: true
            },
            {
                test: /\.css$/i,
                use: ['style-loader', 'css-loader']
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.jsx', '.js'],
        alias: {
            '@': path.resolve(_dirName, 'src'),
            '@store': path.resolve(_dirName, 'src', 'store')
        }
    },
    devServer: {
        static: {
            directory: path.join(_dirName, 'dist')
        },
        historyApiFallback: true,
        open: true,
        https: true
    },
    optimization: {
        runtimeChunk: 'single'
    }
}

module.exports = configCommon