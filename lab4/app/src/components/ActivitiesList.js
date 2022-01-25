import React from 'react';
import SingleActivityRow from './SingleActivityRow';

const ActivitesList = (params) => {
    const activites = params.activities
    console.log(activites)
    return (
        <div>
            {activites.map((activity) =>
                <SingleActivityRow activity={activity} />
            )
            }
        </div>
    )
}

export default ActivitesList;
