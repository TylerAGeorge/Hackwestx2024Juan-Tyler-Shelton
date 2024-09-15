# Hackwestx2024Juan-Tyler-Shelton
 The hackwestx 2024 project for Juan, Tyler, and Shelton

# Cowboy Forum Project 🤠

Our project consists of developing a fun and engaging forum for our fellow cowboys. When creating an account, users receive a "verified" tag, which can range between `Space_Cowboy`, `Sheriff`, and `Raider`. These tags are assigned based on a facial scan that classifies the user into one of these categories, adding a fun twist to the traditional profile creation process.

## Technologies Used

The project used both **MATLAB** and **Python** for model generation. The facial classification model was trained on approximately 13,000 open-source images. Model accuracy reflects a result of 70%.

### MATLAB
MATLAB was employed for the classification of the dataset into three distinct groups:
- **Space_Cowboy**
- **Sheriff**
- **Raider**

#### Criteria for Dividing Faces into the Three Groups

The division of faces was based on **similarity in facial features**, extracted using **Histogram of Oriented Gradients (HOG)** feature descriptors, followed by **K-means clustering**.

#### Grouping Process
- The facial features were extracted using HOG, and the faces were grouped into three categories by clustering their features using K-means.
- Faces with similar structural and textural patterns were grouped into one of the following three categories:

  - **Space_Cowboy**: Faces with certain angular features or specific textures.
  - **Sheriff**: A distinct group with different facial patterns compared to Space_Cowboy.
  - **Raider**: Faces grouped together based on another unique set of features.

The grouping was done algorithmically based on feature similarity rather than manual labeling.

## Face Classification

### How to Run the Face Model:
For this project, a Jupyter Notebook was used, and you will need the following libraries installed:

```bash
pip install opencv-python matplotlib face_recognition tensorflow scipy numpy Pillow h5py

## References
Images used for face classification model: https://www.kaggle.com/datasets/jessicali9530/lfw-dataset
