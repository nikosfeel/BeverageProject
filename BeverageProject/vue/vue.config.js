module.exports = {
    lintOnSave: false,
    productionSourceMap: false,
    filenameHashing: false,
    css: {
      extract: {
        filename: '[name].css'
      }
    },
    configureWebpack: {
      optimization: {
        splitChunks: false
      },
      output: {
        filename: '[name].js'
      },
    },
  }