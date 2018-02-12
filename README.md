# Pong_Game 
Pong Game using Unity

# Machine Learning with ML library
https://unity3d.com/machine-learning
https://github.com/Unity-Technologies/ml-agents/tree/master/docs

# Installing Anaconda with TensorFlow (Windows)
https://unity3d.college/2017/10/25/machine-learning-in-unity3d-setting-up-the-environment-tensorflow-for-agentml-on-windows-10/

# Get sample project
https://github.com/Unity-Technologies/ml-agents
cd into project: $ cd <project_download_folder>/ml-agents/python
$ pip install .

# Issues: Anaconda3
- Problem: conda is not installed properly, though it's part of the package list
- Solution: Used Miniconda instead

# Issues: Miniconda
- Problem: Needed CUDA version 9 instead of version 8 from previous instructions
- Solution: Use this link to get CUDA (https://developer.nvidia.com/cuda-downloads)
-- You will also need update tensorflow with pip: 
-- $ pip install --upgrade tensorflow
-- $ pip install --upgrade tensorflow-gpu

# Issues: Unity Sample Project
- Problem: Scenes loaded, but... doesn't seem to do what was intended.
- Solution: ....