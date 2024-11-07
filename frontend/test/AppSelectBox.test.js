import { mount } from '@vue/test-utils';
import AppSelectBox from '../components/inputs/AppSelectBox.vue'; 

describe('AppSelectBox - isCollapsed tests', () => {

    it('should close the list after selecting an item', async () => {
        const wrapper = mount(AppSelectBox, {
            props: {
                source: ['Option 1', 'Option 2', 'Option 3'],
                current: '',
            },
        });

        await wrapper.find('.relative').trigger('click');

        const firstItem = wrapper.findAll('div.p-3').at(0);
        await firstItem.trigger('click');

        expect(wrapper.find('div.w-full').exists()).toBe(false);

        expect(wrapper.find('.relative p').text()).toBe('Option 1');
    });
});
