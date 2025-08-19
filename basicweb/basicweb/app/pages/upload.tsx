export default function Upload() {
  return (
    <div className="flex flex-col items-center justify-center h-screen">
      <h1 className="text-2xl font-bold mb-4">Upload Page</h1>
      <p className="text-gray-600">This is the upload page where you can upload your photos.</p>
      <form className="mt-4">
        <input
          type="file"
          accept="image/*"
          className="border border-gray-300 rounded-lg p-2"
        />
        <button
          type="submit"
          className="mt-2 bg-blue-500 text-white rounded-lg px-4 py-2 hover:bg-blue-600 transition-colors"
        >
          Upload
        </button>
      </form>
    </div>
  );
};

