const path = require('path');

module.exports = {
    entry: {
        all: './src/all.ts',
        home: './src/home.ts',
        resume: './src/resume.ts',
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
    },
    output: {
        library: {
            name: 'MYAPP',
            type: 'var'
        },
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'wwwroot/js'),
    },
    //mode: 'development',
    optimization: {
        usedExports: true,
        minimize: true
    }
};