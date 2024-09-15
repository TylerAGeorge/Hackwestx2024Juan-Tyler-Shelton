function visualize_groups(image_data, idx, group_names)
    figure;
    num_clusters = length(group_names);
    
    for k = 1:num_clusters
        group_images = find(idx == k);
        
        % checking images from each group
        for i = 1:min(5, length(group_images))
            subplot(num_clusters, 5, (k-1)*5 + i);
            imshow(image_data{group_images(i)});
            title(group_names{k});
        end
    end
end
