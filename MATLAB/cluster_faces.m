function [grouped_faces, idx] = cluster_faces(face_features, num_clusters)
    % applying K-means clustering to the face features
    [idx, ~] = kmeans(face_features, num_clusters);
    
    % group names
    group_names = {'Space_Cowboy', 'Sheriff', 'Raider'};
    
    % faces to groups
    grouped_faces = group_names(idx);
end
