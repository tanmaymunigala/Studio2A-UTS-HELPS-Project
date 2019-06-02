import React from "react";
import Radio from "@material-ui/core/Radio";
import RadioGroup from "@material-ui/core/RadioGroup";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import FormControl from "@material-ui/core/FormControl";
import FormLabel from "@material-ui/core/FormLabel";
import {withStyles} from "@material-ui/core"
import Style from "./Style"

function GenderSelect() {
  const [value, setValue] = React.useState("female");

  function handleChange(event) {
    setValue(event.target.value);
  }

  return (
      <div style={{marginTop:5}}>
    <FormControl component="fieldset">
      <FormLabel component="legend">Gender</FormLabel>
      <RadioGroup
        aria-label="position"
        name="position"
        value={value}
        onChange={handleChange}
        row
      >
        <FormControlLabel
          value="Male"
          control={<Radio color="primary" />}
          label="Male"
          labelPlacement="end"
        />
        <FormControlLabel
          value="Female"
          control={<Radio color="primary" />}
          label="Female"
          labelPlacement="end"
        />
        <FormControlLabel
          value="Other"
          control={<Radio color="primary" />}
          label="Other"
          labelPlacement="end"
        />
      </RadioGroup>
    </FormControl>
    </div>
  );
}
export default withStyles(Style)(GenderSelect);
