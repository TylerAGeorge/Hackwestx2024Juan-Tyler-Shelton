function face_features = detect_and_extract_features(image_data)
    % initializing face detector
    faceDetector = vision.CascadeObjectDetector();
    
    % array for face features
    face_features = [];
    
    % detecting faces
    for i = 1:length(image_data)
        bbox = step(faceDetector, image_data{i});
        
        if ~isempty(bbox)
            face_image = imcrop(image_data{i}, bbox(1, :));  % Crop face
            face_image_resized = imresize(face_image, [224, 224]);
            
            % HOG features
            face_features(i, :) = extractHOGFeatures(face_image_resized);
        end
    end
end
