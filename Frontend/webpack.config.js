const path = require('path');
const VueLoaderPlugin = require('vue-loader').VueLoaderPlugin;
const HtmlWebpackPlugin = require('html-webpack-plugin');
const DefinePlugin = require('webpack').DefinePlugin;

const API_HOST = "'http://157.230.25.160'";
const API_PORT = 5000;

// const API_HOST = "'http://localhost'";
// const API_PORT = 26408;

module.exports = {
  context: path.resolve(__dirname, 'src'),
  entry: './index.js',
  output: {
    publicPath: '/',
    filename: 'bundle.js',
    path: path.resolve(__dirname, 'dist')
  },
  module: {
    rules: [
      {
        test: /\.vue$/,
        loader: 'vue-loader'
      }, {
        test: /\.css$/,
        use: [
          'vue-style-loader',
          'css-loader'
        ]
      }, {
        test: /\.scss$/,
        use: [
          'vue-style-loader',
          'css-loader',
          {
            loader: 'sass-loader',
            options: {
              sassOptions: {
                includePaths: ['src']
              }
            }
          }
        ]
      }
    ]
  },
  plugins: [
    new VueLoaderPlugin(),
    new HtmlWebpackPlugin({
      template: "index-template.html"
    }),
    new DefinePlugin({
      API_HOST,
      API_PORT
    })
  ],
};