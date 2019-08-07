<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

bool bShowFileDialog = true;
string OutputFileName = "spritesheet.paper2dsprites";
	
void Main()
{
	while(true)
	{
		var path = "";
		var spritesheetPath = "";
		var sprite_name = "";
		
		if(bShowFileDialog)
		{
			MessageBox.Show("Choose path to spritesheet data");
			path = GetFilePathFromDialog();
			MessageBox.Show("Choose path to spritesheet png");
			spritesheetPath = GetFilePathFromDialog();
			
			// Expected name ex: fire_pillar_loop.txt
			sprite_name = Path.GetFileName(path);
			var spritesheetIdx = sprite_name.IndexOf('.');
			sprite_name = sprite_name.Substring(0, spritesheetIdx);
		}
		else
		{
			path = "C:\\Users\\tcsil\\Downloads\\ParticleFX\\wills_magic_particle_effects\\wills_magic_particle_effects\\fire_pillar\\spritesheet.txt";
			spritesheetPath = "C:\\Users\\tcsil\\Downloads\\ParticleFX\\wills_magic_particle_effects\\wills_magic_particle_effects\\fire_pillar\\fire_pillar_spritesheet.png";
			sprite_name = "fire_pillar";
		}
		
		path.Dump();
		spritesheetPath.Dump();
		sprite_name.Dump();
		
		var spriteData = ParseSpriteSheetFile(path);
		var outputLines = FormatOutput(spriteData, spritesheetPath, sprite_name);	
		var outputPath = Path.GetDirectoryName(path) + "\\" + sprite_name + "_" + OutputFileName;
		//outputLines.Dump();
		System.IO.File.WriteAllLines(outputPath, outputLines);
		
		$"Saved {outputPath}".Dump();
	}
}
	
string GetFilePathFromDialog()
{
	var browser = new OpenFileDialog();
	browser.ShowDialog();
	return browser.FileName;
}

public class SpriteData
{
	public string SpriteName;
	public int PosX, PosY;
	public int SizeX, SizeY;
	
	public override string ToString()
	{
		return $"Name: {SpriteName} Pos X: {PosX} Y: {PosY} Size X: {SizeX} Y: {SizeY}";
	}
}

// Define other methods and classes here
List<SpriteData> ParseSpriteSheetFile(string path)
{
	string line;  
	
	var spriteDataList = new List<SpriteData>();
  
	// Read the file and display it line by line.  
	System.IO.StreamReader file = new System.IO.StreamReader(path);  
	while((line = file.ReadLine()) != null)  
	{  
		var spriteData = ParseSpriteSheetLine(line);
		//spriteData.ToString().Dump();
	    spriteDataList.Add(spriteData);
	}  
	  
	file.Close();  
	
	return spriteDataList;
}

// Assumes format frame0003 = 302 302 300 300
// Edit this if sprite sheet data is in separate format
SpriteData ParseSpriteSheetLine(string line)
{
	var data = line.Split(' ');
	return new SpriteData()
	{
		SpriteName = data[0],
		PosX = int.Parse(data[2]),
		PosY = int.Parse(data[3]),
		SizeX = int.Parse(data[4]),
		SizeY = int.Parse(data[5]),
	};
}

List<string> FormatOutput(List<SpriteData> spriteDataList, string spriteSheetPath, string sprite_name)
{
	var lines = new List<string>();
	lines.Add("{\"frames\": {");
	
	/*
		"frame0000.png":
		{
			"frame": {"x":0,"y":0,"w":300,"h":300},
			"rotated": false,
			"trimmed": false,
			"spriteSourceSize": {"x":0,"y":0,"w":300,"h":300},
			"sourceSize": {"w":300,"h":300}
		},
	*/
	foreach(var spriteData in spriteDataList)
	{
		lines.Add($"\"{sprite_name}_{spriteData.SpriteName}\":");
		lines.Add("{");
		
		var widthHeightLine = $"{CreateString("w", spriteData.SizeX)}, {CreateString("h", spriteData.SizeY)}";
		var frameLine = $"{{ {CreateString("x", spriteData.PosX)}, {CreateString("y", spriteData.PosY)}, {widthHeightLine} }}";
		lines.Add(CreateString("frame", frameLine) + ",");
		lines.Add(CreateString("rotated", "false") + ",");
		lines.Add(CreateString("trimmed", "false") + ",");
		lines.Add(CreateString("spriteSourceSize", frameLine) + ",");
		lines.Add(CreateString("sourceSize", $"{{ {widthHeightLine} }}"));
		
		lines.Add("},");
	}
	
	// Remove last comma
	lines[lines.Count() - 1] = "}},";
	
	// meta & end
	/* 
		"app": "https://www.codeandweb.com/texturepacker",
		"version": "1.0",
		"target": "paper2d", 
		"image": "texturepacker.png",
		"format": "RGBA8888",
		"size": {"w":3300,"h":3300},
		"scale": "1",
		"smartupdate": "$TexturePacker:SmartUpdate:1a5b69331b3848262fd2fab8795b976d:7cc53206083b21c4c1d66de54307d476:6456fe56111d6ece12a32237dfc7ea8d$"
	}
	*/
	System.Drawing.Image img = System.Drawing.Image.FromFile(spriteSheetPath);
	var sizeLine = $"{{{CreateString("w", img.Width)}, {CreateString("h", img.Height)} }}";
    
	lines.Add("\"meta\": {");
	lines.Add(CreateStringString("app", "https://www.codeandweb.com/texturepacker") + ",");
	lines.Add(CreateStringString("version", "1.0") + ",");
	lines.Add(CreateStringString("target", "paper2d") + ",");
	lines.Add(CreateStringString("image", Path.GetFileName(spriteSheetPath)) + ",");
	lines.Add(CreateStringString("format", "RGBA8888") + ",");
	lines.Add(CreateString("size", sizeLine) + ",");
	lines.Add(CreateStringString("scale", "1") + ",");
	lines.Add(CreateStringString("smartupdate", "$TexturePacker:SmartUpdate:1a5b69331b3848262fd2fab8795b976d:7cc53206083b21c4c1d66de54307d476:6456fe56111d6ece12a32237dfc7ea8d$"));
	lines.Add("}}");
	return lines;
}

string CreateString(string key, int value)
{
	return CreateString(key, value.ToString());
}

string CreateString(string key, string value)
{
	return $"\"{key}\": {value}";
}

string CreateStringString(string key, string value)
{
	return CreateString(key, $"\"{value}\"");
}