function [data_table, image_data, image_names] = load_images(csv_file, base_dir)
    % loading all names CSV
    data_table = readtable(csv_file, 'Delimiter', ',', 'ReadVariableNames', true);
    
    disp(data_table(1:5, :));
    
    folder_names = data_table.name;     % 'name' column
    image_counts = data_table.images;  

    % arrays
    image_data = {};
    image_names = {};
    
    % looping through each folder
    for i = 1:length(folder_names)
        person_name = folder_names{i};  % Name of the person (also the folder name)
        folder_path = fullfile(base_dir, person_name);
        
        if ~isfolder(folder_path)
            warning('Folder %s does not exist.', person_name);
            continue;  % skip to the next folder if it doesn't exist
        end
        
        image_files = dir(fullfile(folder_path, '*.jpg'));
        
        if length(image_files) < image_counts(i)
            warning('Expected %d images but found only %d in folder %s', ...
                    image_counts(i), length(image_files), person_name);
        end
        
        for j = 1:min(image_counts(i), length(image_files))  % Only load the available images
            image_path = fullfile(folder_path, image_files(j).name);
            image = imread(image_path);
            
            % resize image to 224x224
            resized_image = imresize(image, [224, 224]);
            
            % storing the image and name in arrays
            image_data{end+1} = resized_image;
            image_names{end+1} = person_name;
        end
    end
end
