% organize_faces.m

% loading images
[data_table, image_data, image_names] = load_images('../lfw_allnames.csv', '../lfw-deepfunneled/');

% detect faces and extract features
face_features = detect_and_extract_features(image_data);

% divide into 5 groups
num_clusters = 3;
[grouped_faces, idx] = cluster_faces(face_features, num_clusters);

% saving images
group_names = {'Space_Cowboy', 'Sheriff', 'Raider'};
save_grouped_images(image_data, idx, group_names, 'grouped_faces/');

% displaying
visualize_groups(image_data, idx, group_names);
