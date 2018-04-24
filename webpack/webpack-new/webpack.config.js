module.exports={
	entry:"./src/index.js",
	mode:"production",
	output:{
		path: __dirname+"/dist",
		filename:"bundle.js"
	},

	devServer:{
		contentBase:__dirname+"/dist"
	}
};