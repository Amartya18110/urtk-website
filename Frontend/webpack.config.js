const path = require('path');
const VueLoaderPlugin = require('vue-loader').VueLoaderPlugin;
const HtmlWebpackPlugin = require('html-webpack-plugin');
const DefinePlugin = require('webpack').DefinePlugin;

const API_HOST = "157.230.25.160";
const API_PORT = 8000;

// const API_HOST = "localhost";
// const API_PORT = 26408;

module.exports = {
  mode: 'development',
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
      }, {
        test: /\.(png|jpg|svg|ttf)$/,
        loader: 'file-loader',
        options: {
          outputPath: 'assets',
          name(file) {
            console.log('file-loader', file);
            let paths = path.dirname(file).split(path.sep);
            let component = paths[paths.length-1];
            return `${component}/[name].[ext]`
          }
        }
      }
    ]
  },
  plugins: [
    new VueLoaderPlugin(),
    new HtmlWebpackPlugin({
      template: "index-template.html"
    }),
    new DefinePlugin({
      API_HOST: JSON.stringify(`http://${API_HOST}`),
      API_PORT,
      API_ADDRESS: JSON.stringify(`http://${API_HOST}:${API_PORT}/`)
    })
  ],
};