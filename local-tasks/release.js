const gulp = requireModule("gulp-with-help"),
  packageDir = require("./config").packageDir,
  path = require("path"),
  fs = require("fs"),
  runSequence = requireModule("run-sequence"),
  nugetPush = requireModule("nuget-push"),
  env = requireModule("env");
  spawn = requireModule("spawn");

env.associate(["DRY_RUN"], ["push"]);

gulp.task("release", done => {
  runSequence("pack", "push", "commit-release", "tag-and-push", done);
});

gulp.task("push", () => {
  const packages = [
    findNupkg("NExpect"),
    findNupkg("NExpect.Matchers.NSubstitute"),
    findNupkg("NExpect.Matchers.AspNetCore")
  ];
  promises = packages.map(pushPackage);
  return Promise.all(promises);
});

function findNupkg(id) {
  return fs
    .readdirSync(packageDir)
    .filter(p => {
      var parts = p
        .split(".")
        .filter(part => part !== "nupkg" && isNaN(parseInt(part)));
      return parts.join(".") === id;
    })
    .map(p => path.join(packageDir, p))
    .sort()
    .reverse()[0];
}

function pushPackage(package) {
  return nugetPush(package);
}
