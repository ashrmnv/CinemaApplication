import React, {FC} from 'react';
import {Actor} from '../../../../entities/actors/actor';

interface ActorProps{
    actor : Actor;
}

const ActorItem: FC<ActorProps> = ({actor}) : JSX.Element => {
    return(
        <div>
            <div>{actor.firstName} {actor.lastName}</div>
        </div>
    );
}

export default ActorItem;