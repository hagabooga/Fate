git -C .\Authentication\FateUtility\ add -A
git -C .\Client\FateUtility\  add -A
git -C .\Gateway\FateUtility\  add -A
git -C .\Server\FateUtility\  add -A

git -C .\Authentication\FateUtility\ commit --allow-empty-message
git -C .\Client\FateUtility\ commit --allow-empty-message
git -C .\Gateway\FateUtility\ commit  --allow-empty-message
git -C .\Server\FateUtility\ commit --allow-empty-message

git -C .\Authentication\FateUtility\ pull
git -C .\Client\FateUtility\  pull
git -C .\Gateway\FateUtility\  pull
git -C .\Server\FateUtility\  pull

git -C .\Authentication\FateUtility\ push
git -C .\Client\FateUtility\  push
git -C .\Gateway\FateUtility\  push
git -C .\Server\FateUtility\  push


git add -A
git commit
git push