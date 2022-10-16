from asyncio import subprocess
import os
from pathlib import Path
import subprocess

file_path = Path(__file__)
folder = file_path.parent

gits = [f"git -C {project.joinpath('FateCode').absolute()}"
        for project in folder.iterdir()
        if project.is_dir()]

for git in gits:
    subprocess.run(f"{git} pull")
    subprocess.run(f"{git} add -A")
    subprocess.run(
        f"{git} commit --allow-empty -m \"Update\"")
    subprocess.run(f"{git} push")

for git in gits:
    subprocess.run(f"{git} pull")
