import React from 'react';
import { Link, Navigate } from 'react-router-dom';
import { useGlobalState } from '../state';

import { deleteActivity } from '../dataSource/activitiesApi';

const SingleActivityRow = (params) => {
    const activity = params.activity
    const { loggedUser } = useGlobalState()

    const handleDelete = () => {
        deleteActivity(activity.code, loggedUser)
    }

    return <div>
        {activity.code}
        <Link to={{ pathname: "/displayActivity", state: activity }}>
            show
        </Link>
        <Link to={{ pathname: "/updateActivityForm", state: activity }}>
            update
        </Link>

        <input
            type="submit"
            value="delete"
            // className="btn btn-primary"
            style={{ marginTop: '10px' }}
            onClick={handleDelete}
        />
    </div>;
}

export default SingleActivityRow;
