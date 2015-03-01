module.exports = function(grunt) {

  // Project configuration.
  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),
    clean : {
    	src : ["../public/scripts/build",],
    	options : {
		  	force : true,
		  }
    },
		react : {
			jsx:{
				files : [{
		    	expand : true,
		    	cwd : "../public/scripts/jsx",
		    	dest : "../public/scripts/build",
		    	src : "*.jsx",
		    	ext : ".js",
		    }]
		  }
    },
    watch : {
    	jsx : {
	    	files : '../public/scripts/jsx/*.js',
	    	tasks : 'build-jsx'
	    }
	  }
  });

  // Load the plugin that provides the "uglify" task.
  grunt.loadNpmTasks('grunt-react');
  grunt.loadNpmTasks('grunt-reactjsx');
  grunt.loadNpmTasks('grunt-contrib-clean');
  grunt.loadNpmTasks('grunt-contrib-concat');
  grunt.loadNpmTasks('grunt-contrib-less');
  grunt.loadNpmTasks('grunt-contrib-watch');

  // Default task(s).
  grunt.registerTask('build-jsx', ['clean','react']);
  grunt.registerTask('default', ['build-jsx']);//,'watch:jsx']);

};