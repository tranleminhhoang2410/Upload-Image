import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getAllVideoAsync } from '../features/video/videoSlice';

const VideoHome = () => {
    const dispatch = useDispatch();
    const videos = useSelector((state) => state.video.videos);

    console.log(videos);

    useEffect(() => {
        dispatch(getAllVideoAsync());
    }, [dispatch]);

    return (
        <>
            <h1>Video List</h1>
            <ul>
                {videos &&
                    videos.map((video) => (
                        <li key={video.id}>
                            <video controls>
                                <source
                                    src={video.url}
                                    // type='video/mp4'
                                />
                            </video>
                        </li>
                    ))}
            </ul>
        </>
    );
};

export default VideoHome;
