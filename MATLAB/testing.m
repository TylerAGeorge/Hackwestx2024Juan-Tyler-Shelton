% Inspect variable names in the table
data_table = readtable('../lfw_allnames.csv', 'Delimiter', '\t');
disp(data_table.Properties.VariableNames);  % Display actual variable names
