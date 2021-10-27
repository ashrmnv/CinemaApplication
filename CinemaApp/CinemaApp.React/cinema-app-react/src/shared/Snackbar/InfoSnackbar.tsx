import * as React from 'react';
import {FC} from 'react';
import Button from '@mui/material/Button';
import Snackbar from '@mui/material/Snackbar';
import Slide, { SlideProps } from '@mui/material/Slide';

import MuiAlert, { AlertProps, AlertColor } from '@mui/material/Alert';

type TransitionProps = Omit<SlideProps, 'direction'>;

function TransitionUp(props: TransitionProps) {
  return <Slide {...props} direction="up" />;
}

interface SnackbarProps{
  open : boolean;
  setOpen : React.Dispatch<React.SetStateAction<boolean>>;
  type : AlertColor;
  message : string;
};

const InfoSnackbar : FC<SnackbarProps> = ({open, setOpen, type, message}) => {
  const [transition, setTransition] = React.useState<
    React.ComponentType<TransitionProps> | undefined
  >(undefined);

  const handleClose = () => {
    setOpen(false); 
  };

  const Alert = React.forwardRef<HTMLDivElement, AlertProps>(function Alert(
    props,
    ref,
  ) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
  });

  return (
      <Snackbar
          anchorOrigin = {{vertical : 'bottom', horizontal : 'right'}}
          autoHideDuration={3000}
          open={open}
          onClose={handleClose}
          TransitionComponent={TransitionUp}
          key={transition ? transition.name : ''}
      >
      <Alert onClose={handleClose} severity= {type}  sx={{ width: '100%' }}>
          {message}
      </Alert>
    </Snackbar>
  );
}

export default InfoSnackbar;