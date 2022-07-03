import os

paths = (
    "./Authentication/FateCode/",
    "./Client/FateCode/",
    "./Gateway/FateCode/",
    "./Server/FateCode/"
)

for path in paths:
    os.system(f"git -C {path} pull")
    os.system(f"git -C {path} add -A")
    os.system(f"git -C {path} commit -a --allow-empty-message -m ''")
    os.system(f"git -C {path} push")


for path in paths:
    os.system(f"git -C {path} pull")


os.system(f"git add -A")
os.system(f"git commit -a --allow-empty-message -m ''")
os.system(f"git push")
