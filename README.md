# WebP-Converter
Converts WebP file(s) to png, bmp, etc.

![WebP Converter](/README/Form01.png)

## Usage:
1. Select output type. PNG is default.
2. Select one or more files using the "Browse Files" button.
3. Select one or more directories using the "Browse Dirs" button. This will add top-level files in the selected directories.
4. If needed. Rename output files. If not changed, output files will have the same name but with differend extension.
Example: image.webp will convert to image.png.
5. If you want to delete converted files, check the "Delete Converted" checkbox.
6. Press the "Convert" button. If Google's webp tools are not found it will ask if you want to download the tools.
Done.

# Format
Multiple files will format using the ";" (semicolon).
Example: C:/path/to/image/image01.png;C:/path/to/image/image02.png;C:/path/to/image/image03.png etc.

**AFTER** you have selected files. **any changes to the OUTPUT field will change the actual output.**
Changing the path will move the file to the given location.
Changing the file name will convert the image and rename it.
