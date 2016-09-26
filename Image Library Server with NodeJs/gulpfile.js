let gulp = require('gulp')
let htmlMin = require('gulp-htmlmin')

gulp.task('minifyStatus', () => {
  return gulp.src('status.html')
    .pipe(htmlMin({collapseWhitespace: true}))
    .pipe(gulp.dest('build/status.min.html'))
})
