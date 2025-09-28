namespace AbsoluteCinema.PatternExamples.Creational.ObjectPool;

using System.Collections.Concurrent;

public class VideoStreamPool
{
    private readonly ConcurrentBag<VideoStream> _pool = [];
    private readonly HashSet<VideoStream> _activeStreams = [];
    private int _streamCounter;
    private readonly int _maxPoolSize;
    private readonly Lock _lockObject = new();

    public VideoStreamPool(int maxPoolSize = 5)
    {
        _maxPoolSize = maxPoolSize;
        Console.WriteLine($"VideoStreamPool initialized with max size: {maxPoolSize}");

        for (int i = 0; i < maxPoolSize; i++)
        {
            _pool.Add(new VideoStream(++_streamCounter));
        }
    }

    public VideoStream AcquireStream()
    {
        lock (_lockObject)
        {
            if (_pool.TryTake(out var stream))
            {
                Console.WriteLine($"Acquired existing stream {stream.StreamId} from pool");
            }
            else if (_activeStreams.Count < _maxPoolSize)
            {
                stream = new VideoStream(++_streamCounter);
                Console.WriteLine($"Created new stream {stream.StreamId} (pool was empty)");
            }
            else
            {
                Console.WriteLine("Pool is at maximum capacity! Waiting for available stream...");
                return null;
            }

            if (stream != null)
            {
                _activeStreams.Add(stream);
                Console.WriteLine($"Active streams: {_activeStreams.Count}/{_maxPoolSize}");
            }

            return stream;
        }
    }

    public void ReleaseStream(VideoStream stream)
    {
        lock (_lockObject)
        {
            stream.Reset();
            _activeStreams.Remove(stream);
            _pool.Add(stream);

            Console.WriteLine($"Released stream {stream.StreamId} back to pool");
            Console.WriteLine($"Pool size: {_pool.Count}, Active streams: {_activeStreams.Count}");
        }
    }

    public void GetPoolStatus()
    {
        lock (_lockObject)
        {
            Console.WriteLine("\n=== Pool Status ===");
            Console.WriteLine($"Available streams in pool: {_pool.Count}");
            Console.WriteLine($"Active streams: {_activeStreams.Count}");
            Console.WriteLine($"Total capacity: {_maxPoolSize}");
            Console.WriteLine("==================\n");
        }
    }

    public void Cleanup()
    {
        lock (_lockObject)
        {
            Console.WriteLine("Cleaning up VideoStreamPool...");

            foreach (var stream in _activeStreams.ToList())
            {
                stream.StopStream();
                _pool.Add(stream);
            }

            _activeStreams.Clear();
            Console.WriteLine($"All streams returned to pool. Pool size: {_pool.Count}");
        }
    }
}