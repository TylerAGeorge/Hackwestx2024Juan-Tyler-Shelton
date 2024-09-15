function save_grouped_images(image_data, idx, group_names, output_dir)
    % output directories for each group
    for k = 1:length(group_names)
        mkdir(fullfile(output_dir, group_names{k}));
    end
    
    % saving images into its respective group folder
    for i = 1:length(image_data)
        group_name = group_names{idx(i)};
        output_path = fullfile(output_dir, group_name, ['image_' num2str(i) '.jpg']);
        imwrite(image_data{i}, output_path);
    end
end
