const HtmlWebpackPlugin = require('html-webpack-plugin');
const path = require('path');


module.exports = {
//   entry: './src/index.js',
entry:{
    app:'./src/index.js',
    print:'./src/print.js'
},
plugin:[
    new HtmlWebpackPlugin({
        title:'Output Management'
    })
],
  output: {
    // filename: 'bundle.js',
    filename:'[name].bundle.js',
    path: path.resolve(__dirname, 'dist')
  },
//   module: {
//         rules: [
//         {
//             test: /\.css$/,
//             use: [
//             'style-loader',
//             'css-loader'
//                 ]
//             },
//             {
//                 test: /\.(csv|tsv)$/,
//                 use: [
//                 'csv-loader'
//                 ]
//             },
//             {
//                 test: /\.xml$/,
//                 use: [
//                 'xml-loader'
//                 ]
//             }
//         ]
//     }
};
