module.exports = function (grunt) {

    grunt.initConfig({
        "pkg": grunt.file.readJSON("package.json"),
        "jshint": {
            "options": {
                "reporter": require("jshint-stylish")
            },
            "build": ["Grunfile.js",
                "scripts/materialize/*.js",
                "scripts/materialize/date_picker/*.js",]
        },
        "jasmine": {
            "src": ["scripts-prod/global.js", "scripts-prod/login.js"],
            "options": {
                "specs": "test/*.js",
                "keepRunner": true,
                "vendor": "vendor/**/*.js"
            }
        },
        "sass": {
            "dist": {
                "options": {
                    "compass": true,
                    "style": 'expanded',
                    "sourcemap": 'none'
                },
                "files": {
                    'css/exzeology.css': 'sass/exzeology.scss',
                    'css/materialize.css': 'sass/materialize/materialize.scss',
                    'css/print.css': 'sass/print.scss',
                    'css/theme.css': 'sass/theme.scss',
                }
            }
        },
        "cssmin": {
            "add_banner": {
                "options": {
                    "banner": "/*\n <%= pkg.name %> <%= grunt.template.today(\"yyyy-mm-dd\") %> \n*/\n"
                }
            },
            "combine": {
                "files": {
                    "css-min/exzeology.min.css": ["css/exzeology.css"],
                    'css-min/materialize.min.css': 'css/materialize.css',
                    "css-min/print.min.css": ["css/print.css"],
                    "css-min/theme.min.css": ["css/theme.css"],
                }
            }
        },
        
        "concat": {
            "options": {
                "banner": "/*\n <%= pkg.name %> <%= grunt.template.today(\"yyyy-mm-dd\") %> \n*/\n"
            },
            "scripts-dev/materialize.js": ["js/*.js"],
        },
        
        "watch": {
            "scripts": {
                "files": ["js/*.js", "sass/materialize/*.scss", "sass/*.scss"],
                "tasks": ["jshint", "newer:concat", "newer:uglify", "sass", "cssmin"],
                "options": {
                    "spawn": false
                },
            }
        },
        
        "uglify": {
            "options": {
                "banner": "/*\n <%= pkg.name %> <%= grunt.template.today(\"yyyy-mm-dd\") %> \n*/\n"
            },
            "build": {
                "files": {
                    "scripts-prod/materialize-min.js": ["js/*.js"],
                }
            }
        }

    });
    grunt.event.on("watch", function (action, filepath, target) {
        grunt.log.writeln(target + ": " + filepath + " has " + action);
    });
    grunt.registerTask("start", ["watch"]);
    grunt.registerTask("dev", ["jshint", "newer:concat", "sass"]);
    grunt.registerTask("prod", ["jshint", "newer:uglify", "sass", "cssmin"]);
    grunt.registerTask("min", ["jshint", "newer:concat", "newer:uglify"]);
    grunt.registerTask("forcemin", ["jshint", "concat", "uglify"]);
    grunt.registerTask("test", ["jasmine"]);
    grunt.registerTask("build", ["jshint", "concat", "uglify", "cssmin", "test"]);
    grunt.loadNpmTasks("grunt-contrib-jshint");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-concat");
    grunt.loadNpmTasks('grunt-contrib-jasmine')
    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-newer");
    grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-compass');
};
