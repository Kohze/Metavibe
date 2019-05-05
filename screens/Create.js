import React from 'react';
import { ScrollView, StyleSheet } from 'react-native';
import { TextInput } from 'react-native-paper';
import { Button } from 'react-native-paper';
import { Image, View } from 'react-native';
import { ImagePicker } from 'expo';
import { ToggleButton } from 'react-native-paper';

export default class Create extends React.Component {
  static navigationOptions = {
    title: 'Create new Vibe',
  };

    constructor (props) {
       super(props)
       this.state = {
         title: '',
         description: '',
         text: '',
         status: 'checked',
         image: null,
       }
    }




  render() {
    let { image } = this.state;
    /* Go ahead and delete ExpoConfigView and replace it with your
     * content, we just wanted to give you a quick view of your config */
    return (
      <ScrollView style={styles.container}>
        {/* Go ahead and delete ExpoLinksView and replace it with your
           * content, we just wanted to provide you with some helpful links */}
      <TextInput
        label='Title'
        value={this.state.title}
        onChangeText={title => this.setState({ title })}
      />

      <TextInput
        label='Description'
        value={this.state.description}
        onChangeText={description => this.setState({ description })}
      />

      <TextInput
        label='Type'
        value={this.state.text}
        onChangeText={text => this.setState({ text })}
      />

      <ToggleButton
        icon="bluetooth"
        value="bluetooth"
        status={this.state.status}
        onPress={value =>
          this.setState({
            status: value === 'checked' ? 'unchecked' : 'checked',
          })
        }
      />
      
      <TextInput
        label='Security Model'
        value={this.state.text}
        onChangeText={text => this.setState({ text })}
      />

        <Button icon="add-a-photo" mode="contained" onPress={this._pickImage}>
          Upload Picture
        </Button>
        <View style={{ flex: 1, alignItems: 'center', justifyContent: 'center' }}>
   
        {image &&
          <Image source={{ uri: image }} style={{ width: 400, height: 225 }} />}
      </View>
      </ScrollView>
    );
  }

   _pickImage = async () => {
    let result = await ImagePicker.launchImageLibraryAsync({
      allowsEditing: true,
      aspect: [16, 9],
    });

    console.log(result);

    if (!result.cancelled) {
      this.setState({ image: result.uri });
    }
  };
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 15,
    backgroundColor: '#fff',
  },
});
