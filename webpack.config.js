const path = require("path");
const webpack = require("webpack");
const VueLoaderPlugin = require("vue-loader/lib/plugin");
//const ExtractTextPlugin = require('extract-text-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const bundleOutputDir = "./wwwroot/dist";

module.exports = env => {
	const isDevBuild = !(env && env.prod);
	return [
		{
			stats: { modules: false },
			entry: { main: "./ClientApp/boot-app.js" },
			resolve: {
				extensions: [".js", ".vue"],
				alias: {
					vue$: "vue/dist/vue",
					components: path.resolve(
						__dirname,
						"./ClientApp/components"
					),
					views: path.resolve(__dirname, "./ClientApp/views"),
					utils: path.resolve(__dirname, "./ClientApp/utils"),
					api: path.resolve(__dirname, "./ClientApp/store/api")
				}
			},
			output: {
				path: path.join(__dirname, bundleOutputDir),
				filename: "[name].js",
				publicPath: "/dist/"
			},
			module: {
				rules: [
					{ test: /\.vue$/, include: /ClientApp/, use: "vue-loader" },
					{
						test: /\.js$/,
						include: /ClientApp/,
						use: "babel-loader"
					},
					{
						test: /\.css$/,
						use: isDevBuild
							? ["style-loader", "css-loader"]
							: [MiniCssExtractPlugin.loader, "css-loader"]
					},
					{
						test: /\.(png|jpg|jpeg|gif|svg)$/,
						use: "url-loader?limit=25000"
                    },
                    {
                        test: /\.pug$/,
                        loader: 'pug-plain-loader'
                    }
				]
			},
			plugins: [
				new webpack.DllReferencePlugin({
					context: __dirname,
					manifest: require("./wwwroot/dist/vendor-manifest.json")
                }),
                new VueLoaderPlugin()
			].concat(
				isDevBuild
					? [
							// Plugins that apply in development builds only
							new webpack.SourceMapDevToolPlugin({
								filename: "[file].map", // Remove this line if you prefer inline source maps
								moduleFilenameTemplate: path.relative(
									bundleOutputDir,
									"[resourcePath]"
								) // Point sourcemap entries to the original file locations on disk
							})
					  ]
					: [
							// Plugins that apply in production builds only
							new webpack.optimize.UglifyJsPlugin({
								compress: {
									warnings: false
								}
							}),
							new MiniCssExtractPlugin("site.css")
							//new ExtractTextPlugin('site.css')
					  ]
			)
		}
	];
};
