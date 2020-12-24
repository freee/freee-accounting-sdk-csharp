module.exports = async ({ github, context }) => {
  const ownerAndRepoName = context.payload.repository.full_name.split('/');
  const owner = ownerAndRepoName[0];
  const repo = ownerAndRepoName[1];
  let version = '';
  try {
    const res = await github.repos.getLatestRelease({
      owner,
      repo,
    });
    const { tag_name } = res.data;
    const index = tag_name.indexOf('v');
    if (0 <= index) {
      version = tag_name.slice(index + 1);
    } else {
      version = tag_name;
    }
  } catch (e) {
    if (e.status == 404) {
      console.log('Release is not found, so set version 0.0.0.');
      version = '0.0.0';
    } else {
      throw e;
    }
  }
  return version;
}
